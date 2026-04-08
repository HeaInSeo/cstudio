# AGENTS.md

## Workspace Intent

This repository builds `cstudio`, an Avalonia desktop shell inspired by `GPU-Reshape` Studio and intended for later integration with `DagEdit`.

## Session Startup

Before making changes:

1. Read `README.md` if present
2. Read `docs/` for sprint plans and architecture notes
3. Check `git status`
4. Keep the current sprint scope explicit

## Working Rules

- Preserve product-neutral architecture
- Use `GPU-Reshape/Source/UIX/Studio` as the UI reference
- Do not introduce direct dependencies on `GRS.*`, `Bridge.CLR`, `Message.CLR`, `HostResolver`, or `Discovery`
- Build the shell against mock data first
- Follow `DagEdit` static-analysis discipline as the baseline guardrail direction
- Ask before destructive actions

## Architecture Guardrails

- Keep `App`, `Core`, `Mock`, and future adapters separated
- Prefer interface-first design for services
- Keep workspace, documents, tools, properties, and logs reusable
- Avoid coupling view models to backend protocol types

## Quality Guardrails

- New build-time warnings must not increase
- Warning reduction work should be tracked separately from feature work when possible
- Do not weaken analyzer settings to hide findings
- Prefer Rider-compatible code style that trends toward zero warnings
- When static-analysis rules change, document the operating policy in `docs/`

## Documentation

- Record sprint outcomes in `docs/`
- Publish a screenshot note at the end of each sprint
- Write down structural decisions when they affect future `DagEdit` integration
- When the UI changes in a meaningful way, update the GitHub-viewable screenshot documentation and push it
- Keep screenshot documentation current throughout ongoing UI work, not only at sprint close
