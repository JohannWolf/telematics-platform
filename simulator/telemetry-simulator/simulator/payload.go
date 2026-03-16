package simulator

import "time"

type TelemetryPayload struct {
	TenantId          string    `json:"tenantId"`
	VehicleId         string    `json:"vehicleId"`
	Speed             float64   `json:"speed"`
	EngineTemperature float64   `json:"engineTemperature"`
	FuelLevel         float64   `json:"fuelLevel"`
	Latitude          float64   `json:"latitude"`
	Longitude         float64   `json:"longitude"`
	Timestamp         time.Time `json:"timestamp"`
}