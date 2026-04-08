# CStudio Roadmap

## Purpose

This roadmap tracks the overall delivery plan for `cstudio`, the intermediate shell project meant to reduce future UI migration cost into `DagEdit`.

This file must be updated at the end of every sprint.

Korean version:

- [ROADMAP.ko.md](ROADMAP.ko.md)

## Status Summary

- Sprint 00: Completed
- Sprint 01: Completed
- Sprint 02: Completed
- Sprint 03: Completed
- Sprint 04+: Planned / Next

## Roadmap

| Sprint | Name | Goal | Status | Notes |
|---|---|---|---|---|
| 00 | Foundation | Create repository, baseline shell, settings, mock-backed app | Completed | Built and pushed |
| 01 | Shell Parity | Move shell structure closer to `GPU-Reshape Studio` | Completed | Top chrome, dock-host feel, status split |
| 02 | Shell Contracts | Define adapter-ready workspace/document/service contracts | Completed | Composition root and service boundaries established |
| 03 | First Adapter Pass | Connect selected shell surfaces to `DagEdit` side data/contracts | Completed | DagEdit-backed adapter project added |
| 04 | Tooling and Interaction | Improve real interactions, selection flow, and panel sync | Planned | Depends on Sprint 02 output |
| 05 | Stabilization | Clean-up, packaging direction, test hardening, migration prep | Planned | May split if scope grows |

## Sprint Update Rule

At the end of each sprint:

1. Update the status table in this file
2. Add or update the sprint note in `docs/sprints/`
3. Add or update the screenshot note in `docs/screenshots/`
4. Push the results to GitHub

## Ongoing UI Update Rule

Whenever the UI changes in a major or clearly visible way:

1. Update the corresponding screenshot note
2. Update the GitHub-viewable preview image or screenshot asset
3. Push the updated UI state to GitHub

This rule stays active for all future work unless explicitly changed.

## Current Focus

Sprint 04 is the next focus area:

- deeper interaction mapping from DagEdit into shell panels
- improved tool/document semantics over adapter data
- keeping the adapter path optional and reusable
