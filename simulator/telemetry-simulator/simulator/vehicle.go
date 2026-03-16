package simulator

import (
	"math/rand"
	"time"

	"github.com/google/uuid"
)

type Vehicle struct {
	TenantId  string
	VehicleId string
}

func NewVehicle() Vehicle {
	return Vehicle{
		TenantId:  uuid.New().String(),
		VehicleId: uuid.New().String(),
	}
}

func (v Vehicle) GenerateTelemetry() TelemetryPayload {

	return TelemetryPayload{
		TenantId:          v.TenantId,
		VehicleId:         v.VehicleId,
		Speed:             rand.Float64()*120 + 10,
		EngineTemperature: rand.Float64()*40 + 70,
		FuelLevel:         rand.Float64() * 100,
		Latitude:          19.4326 + rand.Float64()/10,
		Longitude:         -99.1332 + rand.Float64()/10,
		Timestamp:         time.Now().UTC(),
	}
}