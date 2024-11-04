from setuptools import setup, find_packages

# Read the contents of requirements.txt for dependencies
with open("requirements.txt") as f:
    requirements = f.read().splitlines()

setup(
    name="SapiensData-DRMAV",
    version="0.1.0",
    description="",
    long_description=open("README.md").read(),
    long_description_content_type="text/markdown",
    author="Reza Nazari, Janusz Sliwinski",
    author_email="reza2003n@gmail.com",
    url="hhttps://gitlab.com/bktmpdr/itas/2022_ait/ait30v-2025_25/projektarbeit/01-self-driven-learning-project/reza-janusz/sapiensdata-drmav",  
    packages=find_packages("src"),
    package_dir={"": "src"},
    include_package_data=True,
    install_requires=requirements,
    classifiers=[
        "Programming Language :: Python :: 3",
        "Operating System :: OS Independent",
        "Intended Audience :: Developers",
        "Topic :: Software Development :: Libraries :: Python Modules",
        "Topic :: Scientific/Engineering :: Artificial Intelligence",
    ],
    python_requires=">=3.8",
    project_urls={
        "Bug Tracker": "https://gitlab.com/bktmpdr/itas/2022_ait/ait30v-2025_25/projektarbeit/01-self-driven-learning-project/reza-janusz/sapiensdata-drmav/issues",  
        "Documentation": "https://gitlab.com/bktmpdr/itas/2022_ait/ait30v-2025_25/projektarbeit/01-self-driven-learning-project/reza-janusz/sapiensdata-drmav/wiki",  
        "Source Code": "https://gitlab.com/bktmpdr/itas/2022_ait/ait30v-2025_25/projektarbeit/01-self-driven-learning-project/reza-janusz/sapiensdata-drmav",  
    },
)
