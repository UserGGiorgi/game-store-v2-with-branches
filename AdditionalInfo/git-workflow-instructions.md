# Git Workflow Instructions

This document outlines the workflow for working with Git branches, ensuring smooth integration while preserving specific folder contents. The process follows a structured pipeline where you'll work on specific features, merge their changes, and ensure proper integration using GitLab CI/CD.

## Workflow Overview

- Implement the fitures of the `Epic #` in the `game-store-epic-#` branch, commit, and push code to the remote repository.
- Create a merge request.
- CI/CD runs automated build process and tests (starting from the Epic 2).
  - If tests fail, merge request cannot be merged.
  - If tests pass, mentor approval is required.
- Mentor reviews and approves the merge request.
- Merge the feature branch into `main`, replacing required files, if needed.
- Before the next epic, sync `main` with the next branch, ensuring updates.

## Step-by-Step Process

- Switch to a Feature Branch
```
git checkout game-store-epic-#
```
- Merge `main` into `game-store-epic-#`, keeping the common folder unchanged
```
git merge -X ours main
```
_This ensures `game-store-epic-#` gets the latest updates from `main`, while retaining its own common folder._
-  Implement Changes and Push Updates
  - Make necessary code modifications.
  - Commit and push your changes:

```
git add .
git commit -m "Implemented epic #"
git push origin game-store-epic-#
```
- Create a merge request
  - Open autocode.git.epam and navigate to your repository.
  - Create an merge request from `game-store-epic-#` to `main`.