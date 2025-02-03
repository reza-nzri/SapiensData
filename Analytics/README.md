# SapiensData.Analytics

- Responsible for analytics and data processing, including AI models (Python) and data visualization (e.g. R).
- Performs receipt analysis, OCR processes and financial reporting.

## 📌 **Installation Guide**

### **Prerequisites ✔️**

Before you begin, ensure you have the following installed on your machine:

- Python 3.8 or higher
- For your own .ENV:
  - OpenAI API key
  - Sapiens API key to connect to and authorize the SapiensDataAPI subproject (identical to your `SAPIENS_ANALYZER_SERVER_KEY` variable from `SapiensDataAPI/.env`)
  - A Google Drive folder path
  - For more information, see the `Analytics/.env.dev.example` file.

### Go to the Analytics Subproject Folder

`cd Analytics`

Recommended: Open this path with vs code to select the Python interpreter in the IDE as the environment isolator method for this subproject only. The root and each subproject is better to open in vs code separately.

## 🏆 **For Normal Users**

### 1️⃣ **Create & Activate Virtual Environment**

### **On macOS/Linux:**

```bash
python3 -m venv venv
source venv/bin/activate
```

### **On Windows:**

```bash
python -m venv venv
venv\Scripts\activate
```

### 2️⃣ **Install Dependencies**

📦 `pip install -r requirements.txt`

### 3️⃣ **Set Up Environment Variables**

📝 `cp .env.dev.example .env.dev`

⚙️ **Edit `.env.dev` and configure your variables**

### 4️⃣ **Run the Application**

 `python src/main.py`

### 5️⃣ **Exit Virtual Environment (Optional)**

🔚 `deactivate`

## 👨‍💻 **For Contributors & Developers**

### **1️⃣ Configure Git**

```bash
git config user.name "Your User Name"
git config user.email "your-email@example.com"
```

### **2️⃣ Set Up Git Flow**

```bash
git flow init
```

- Use **default settings** when prompted.

### **3️⃣ Create & Activate Virtual Environment**

### **On macOS/Linux:**

```bash
python3 -m venv venv
source venv/bin/activate
```

### **On Windows:**

```bash
python -m venv venv
venv\Scripts\activate
```

### **4️⃣ Install Dependencies**

```bash
pip install -r requirements.txt
```

### **5️⃣ Set Up Environment Variables**

```bash
cp .env.dev.example .env.dev
```

🛠️ **Edit `.env.dev` and set required values.**

### **6️⃣ Create a New Feature Branch**

```bash
git checkout develop  # Always start from the develop branch
git checkout -b feature/your-feature-name
```

### **7️⃣ Make Changes & Commit**

```bash
git add .
git commit -m "🔧 Add new feature: description"
```

### **8️⃣ Push Changes & Create a Pull Request**

```bash
git push origin feature/your-feature-name
```

🔄 **Go to GitHub and open a Pull Request (PR) to the `develop` branch.**

---

💡 **Tips for Contributors:**

- Use `pip freeze > requirements.txt` to update dependencies.
- **Keep your branch updated** → `git pull origin develop`
- **Follow commit message conventions**
- **Use Git Flow for structured development**

🚀 **Happy coding!** 🎉
