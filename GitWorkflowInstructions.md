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
