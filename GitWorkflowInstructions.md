# Git Workflow Instructions

This document outlines the workflow for working with Git branches, ensuring smooth integration while preserving specific folder contents. The process follows a structured pipeline where you'll work on specific features, merge their changes, and ensure proper integration using GitLab CI/CD.


## Workflow Overview

- Implement the fitures of the `game-store-epic-0N` branch, commit, and push them to the remote repository.
- Create a merge request.
- CI/CD runs automated build process and tests (if they exist).
  - If tests fail, merge request cannot be merged.
  - If tests pass, mentor approval is required.
- Mentor reviews and approves the merge request.
- Merge the feature branch into `main`, replacing required files, if needed.
- Before the next stage, sync `main` with the next `game-store-epic-0N+1` branch, ensuring updates.


## Step-by-Step Process

- Switch to a Feature Branch
```
git checkout `game-store-epic-0N`
```
- Merge `main` into `game-store-epic-0N`, keeping the common folder unchanged
```
git merge -X ours main
```
This ensures `game-store-epic-0N` gets the latest updates from `main`, while retaining its own common folder.
-  Implement Changes and Push Updates
  - Make necessary code modifications.
  - Commit and push your changes:

```
git add .
git commit -m "Implemented epic 0N"
git push origin `game-store-epic-0N`
```
- Create a merge request
  - Open GitLab and navigate to your repository.
  - Create an merge request from s`game-store-epic-0N` to `main`.