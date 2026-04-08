# Sprint 02 - Shell Contracts

## Goal

Replace the direct mock-to-viewmodel wiring with adapter-ready shell service contracts.

## Scope

- split shell data access into dedicated core service interfaces
- move mock implementations into `CStudio.Mock`
- make `App` the composition root for shell services
- make `MainWindowViewModel` depend on contracts instead of concrete mock creation
- keep selection-driven property updates inside contract boundaries

## Done Criteria

- app builds successfully
- `MainWindowViewModel` no longer creates mock services directly
- shell state is composed through `Core` contracts
- GitHub-viewable screenshot note is updated

## Status

Completed.
