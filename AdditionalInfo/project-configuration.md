# Gamestore template

Sample files to setup working CI pipeline.

## Requirements

* Update Visual Studio to latest version (2022+).
* All test should be consolidated in one test project.
* Test project should reference `coverlet.msbuild` package.
* Solution must be located in `Gamestore` folder.

## Installation

Copy [.gitlab-ci.yml](.gitlab-ci.yml) file to repository root folder.  
Copy two files to solution folder
* [Directory.Build.props](Directory.Build.props)
* [.editorconfig](.editorconfig)

## Usage

IDE will highlight errors and suggest fixes based on rule set from `.editorconfig` file which is automatically loaded.  

Pipeline run will be triggered on every push event and run results can be viewed at `merge request` details page or at `CI/CD` -> `Pipelines` section of your project at https://git.epam.com/.
Results will include total test coverage.


## Gamestore CI/CD Template  

### Description  
A template for setting up a CI pipeline for the **Gamestore** project.  

### Requirements  
- Update Visual Studio to the latest version (2022+).  
- All tests should be consolidated into a single test project.  
- The test project must reference the `coverlet.msbuild` package.  
- The solution must be located in the **Gamestore** folder.  

### Installation  
1. Copy the [.gitlab-ci.yml](.gitlab-ci.yml) file to the repository root folder.  
2. Copy the following files to the solution folder:  
   - [Directory.Build.props](Directory.Build.props)  
   - [.editorconfig](.editorconfig)  

### Usage  
- **IDE Integration**: Errors and suggestions will be highlighted based on the rule set from `.editorconfig`, which is automatically loaded.  
- **CI/CD Pipeline**: The pipeline runs on every push.  
  - Results can be viewed in the Merge Request details page or in the **CI/CD → Pipelines** section of your project at [git.epam.com](https://git.epam.com/).  
  - The report includes total test coverage.  
