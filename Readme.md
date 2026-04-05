# Telematics Platform

A multi-tenant telemetry monitoring platform capable of processing vehicle telemetry and generating alerts based on configurable rules.

## Backend

- ASP.NET Core
- PostgreSQL
- Docker

## Frontend
- Vite with React

## Architecture
- Clean Architecture for the Backend
- Feature-Based Architecture for the UI

## Features
- Vehicle telemetry ingestion
- Rule-based alerting
- Fleet monitoring dashboard
- Multi-tenant architecture
- Terraform + AWS + Docker Deployment

## Final goal architecture
Telemetry Platform

- Vehicles API
- Telemetry Ingestion
- Telemetry Query API
- Rule Engine
- Alert Engine
- Alert Query API
- Rule Management API
- JWT and RBAC Auth
- Dashboard UI

## System Architecture
```mermaid
flowchart LR

User[User / Operator] --> UI[React Dashboard UI]

UI -->|JWT Auth| API[Telemetry API .NET]

API --> Ingest[Telemetry Ingestion Service]
API --> Query[Telemetry Query Service]
API --> Rules[Rule Engine Service]
API --> Alerts[Alert Service]
API --> Vehicles[Vehicle Service]

Ingest --> DB[(PostgreSQL)]
Query --> DB
Rules --> DB
Alerts --> DB
Vehicles --> DB

API --> OpenAPI[OpenAPI / Swagger]

subgraph AWS EC2
UI
API
DB
end

Terraform[Terraform] --> AWS[AWS EC2 Infrastructure]
AWS --> UI
AWS --> API
AWS --> DB
```

## Backend Component Diagram 
```mermaid
flowchart TB

Controller[TelemetryController] --> UseCase[IngestTelemetryUseCase]

UseCase --> RuleEngine[RuleEngine]

RuleEngine --> AlertService[AlertService]

UseCase --> Repo[TelemetryRepository]

AlertService --> AlertRepo[AlertRepository]

Repo --> DB[(PostgreSQL)]
AlertRepo --> DB

Controller --> QueryUseCase[GetTelemetryUseCase]

QueryUseCase --> Repo

Controller --> VehicleUseCase[VehicleUseCase]

VehicleUseCase --> VehicleRepo[VehicleRepository]

VehicleRepo --> DB
```

## Deployment Diagram
```mermaid
flowchart TB

Terraform --> EC2[AWS EC2 Instance]

EC2 --> Docker[Docker Compose]

Docker --> API[Telemetry API Container]
Docker --> UI[React UI Container]
Docker --> DB[(PostgreSQL Container)]

UI --> API
API --> DB
```