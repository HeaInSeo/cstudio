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
- Sprint 04: Completed
- Sprint 05: Completed
- Sprint 06+: Planned / Next

## Roadmap

| Sprint | Name | Goal | Status | Notes |
|---|---|---|---|---|
| 00 | Foundation | Create repository, baseline shell, settings, mock-backed app | Completed | Built and pushed |
| 01 | Shell Parity | Move shell structure closer to `GPU-Reshape Studio` | Completed | Top chrome, dock-host feel, status split |
| 02 | Shell Contracts | Define adapter-ready workspace/document/service contracts | Completed | Composition root and service boundaries established |
| 03 | First Adapter Pass | Connect selected shell surfaces to `DagEdit` side data/contracts | Completed | DagEdit-backed adapter project added |
| 04 | Embedded Canvas | Place a real DagEdit canvas inside the cstudio document host | Completed | Center document area now hosts a live DagEdit editor surface |
| 05 | Interactive Shell Sync | Feed embedded canvas viewport and selection state into shell panels | Completed | Properties, logs, workspace label, and status now react to live canvas state |
| 06 | Stabilization | Clean-up, packaging direction, test hardening, migration prep | Planned | May split if scope grows |

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

Sprint 06 is the next focus area:

- tighten adapter boundaries and reduce duplication around embedded graph seeding
- decide packaging direction for reusing this shell in DagEdit
- harden tests and polish visual parity details
