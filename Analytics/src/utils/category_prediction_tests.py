from transformers import BertForSequenceClassification, BertTokenizer
import torch
import os

# Load model and tokenizer
script_dir = os.path.dirname(os.path.abspath(__file__))
model_path = os.path.join(script_dir, '..', 'models', 'category_classifier_model')

model = BertForSequenceClassification.from_pretrained(model_path)
tokenizer = BertTokenizer.from_pretrained(model_path)
model.eval()

# Define label mapping
label_mapping = {'Fruit': 0, 'Vegetable': 1}  # Adjust this to your actual mapping

# Prediction function
def predict_category(item):
    inputs = tokenizer(item, return_tensors='pt', padding=True, truncation=True)
    with torch.no_grad():
        outputs = model(**inputs)
        prediction = torch.argmax(outputs.logits, dim=1).item()
    return list(label_mapping.keys())[prediction]

# Test cases
def test_predict_category():
    test_cases = [
        {"item": "Banana", "expected": "Fruit"},
        {"item": "Carrot", "expected": "Vegetable"},
        {"item": "Apple", "expected": "Fruit"},
        {"item": "Spinach", "expected": "Vegetable"},
        {"item": "Orange", "expected": "Fruit"},
        {"item": "Tomato", "expected": "Vegetable"},   # Can sometimes be classified as a fruit, depending on the context
        {"item": "Lettuce", "expected": "Vegetable"},
        {"item": "Strawberry", "expected": "Fruit"},
        {"item": "Potato", "expected": "Vegetable"},
        {"item": "Grape", "expected": "Fruit"},
        {"item": "Cucumber", "expected": "Vegetable"},
        {"item": "Watermelon", "expected": "Fruit"},
        {"item": "Broccoli", "expected": "Vegetable"},
        {"item": "Pineapple", "expected": "Fruit"},
        {"item": "Celery", "expected": "Vegetable"}
    ]

    passed, failed = 0, 0

    for i, test in enumerate(test_cases):
        item = test["item"]
        expected = test["expected"]
        predicted = predict_category(item)

        if predicted == expected:
            passed += 1
        else:
            failed += 1
            print(f"Test case {i+1} failed: '{item}' was expected to be '{expected}' but got '{predicted}'")
    
    print(f"\nBasic Classification Tests: {passed} passed, {failed} failed")

# Additional edge case tests
def test_edge_cases():
    passed, failed = 0, 0

    # Edge Case 1: Empty input
    try:
        result = predict_category("")
        print(f"Edge case test (empty input) passed: Got '{result}' for empty input")
        passed += 1
    except Exception as e:
        print(f"Edge case test (empty input) failed: {e}")
        failed += 1

    # Edge Case 2: Non-food item
    try:
        result = predict_category("Laptop")
        print(f"Edge case test (non-food item) passed: Got '{result}' for 'Laptop'")
        passed += 1
    except Exception as e:
        print(f"Edge case test (non-food item) failed: {e}")
        failed += 1

    # Edge Case 3: Punctuation-only input
    try:
        result = predict_category("!!!")
        print(f"Edge case test (punctuation) passed: Got '{result}' for '!!!'")
        passed += 1
    except Exception as e:
        print(f"Edge case test (punctuation) failed: {e}")
        failed += 1

    print(f"\nEdge Case Tests: {passed} passed, {failed} failed")

# Run tests
test_predict_category()
test_edge_cases()
