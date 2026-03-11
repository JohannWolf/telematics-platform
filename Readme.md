# Telematics Platform

A multi-tenant telemetry monitoring platform capable of processing vehicle telemetry and generating alerts based on configurable rules.

## Backend

- ASP.NET Core
- PostgreSQL
- Docker

## Frontend
- React

## Architecture
- Clean Architecture
- Event Driven (planned)

## Features
- Vehicle telemetry ingestion
- Rule-based alerting
- Fleet monitoring dashboard
- Multi-tenant architecture
- Docker deployment

### Telematics flow:

    Vehicle sends telemetry
        ↓
    API receives telemetry
            ↓
    Save telemetry
            ↓
    Load rules
            ↓
    Evaluate rules
            ↓
    Create alert if rule matches


