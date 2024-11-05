# Analytics\src\utils\bert_category_training.py
import pandas as pd
from transformers import BertTokenizer, BertForSequenceClassification, AdamW
import torch
from torch.utils.data import Dataset, DataLoader
from sklearn.model_selection import train_test_split
import os

# Load and prepare data
script_dir = os.path.dirname(os.path.abspath(__file__))
cvs_path = os.path.join(script_dir, '..', '..', 'dataset', 'train', 'categories', 'categories.csv')
df = pd.read_csv(cvs_path)

label_mapping = {label: idx for idx, label in enumerate(df['category'].unique())}
df['label'] = df['category'].map(label_mapping)

# Initialize tokenizer
tokenizer = BertTokenizer.from_pretrained('bert-base-uncased')

# Tokenization function
def tokenize(texts):
    return tokenizer(texts, padding=True, truncation=True, return_tensors='pt')

class CategoryDataset(Dataset):
    def __init__(self, texts, labels):
        self.encodings = tokenize(texts)
        self.labels = labels

    def __len__(self):
        return len(self.labels)

    def __getitem__(self, idx):
        return {key: val[idx] for key, val in self.encodings.items()}, self.labels[idx]

# Split data into training and test sets
train_texts, val_texts, train_labels, val_labels = train_test_split(
    df['item'].tolist(), df['label'].tolist(), test_size=0.2
)

train_dataset = CategoryDataset(train_texts, train_labels)
val_dataset = CategoryDataset(val_texts, val_labels)

train_loader = DataLoader(train_dataset, batch_size=4, shuffle=True)
val_loader = DataLoader(val_dataset, batch_size=4)

# Load pre-trained model
model = BertForSequenceClassification.from_pretrained('bert-base-uncased', num_labels=len(label_mapping))
optimizer = AdamW(model.parameters(), lr=1e-5)

# Training loop
model.train()
for epoch in range(5):
    for batch, labels in train_loader:
        optimizer.zero_grad()
        outputs = model(**batch, labels=torch.tensor(labels))
        loss = outputs.loss
        loss.backward()
        optimizer.step()
    print(f'Epoch {epoch + 1}, Loss: {loss.item()}')

# Save model
model_path = os.path.join(script_dir, '..', 'models', 'category_classifier_model')
model.save_pretrained(model_path)
tokenizer.save_pretrained(model_path)
