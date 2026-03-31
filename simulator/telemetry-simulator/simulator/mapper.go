package simulator

import (
	"strconv"
	"time"
	"telemetry-simulator/dataset"
)

func MapToPayload(raw dataset.RawTelemetry) TelemetryPayload {

	speed, _ := strconv.ParseFloat(raw.Speed, 64)
	temp, _ := strconv.ParseFloat(raw.Temp, 64)

	return TelemetryPayload{
		TenantId:          "demo-tenant",
		VehicleId:         raw.DeviceID,
		Speed:             speed,
		EngineTemperature: temp,
		FuelLevel:         50,
		Latitude:          19.43,
		Longitude:         -99.13,
		Timestamp:         time.Now().UTC(),
	}
}