package simulator

import (
	"time"
)

type Simulator struct {
	vehicles []Vehicle
	apiURL   string
	interval int
}

func NewSimulator(vehicleCount int, apiURL string, interval int) *Simulator {

	var vehicles []Vehicle

	for i := 0; i < vehicleCount; i++ {
		vehicles = append(vehicles, NewVehicle())
	}

	return &Simulator{
		vehicles: vehicles,
		apiURL:   apiURL,
		interval: interval,
	}
}

func (s *Simulator) Start() {

	for _, vehicle := range s.vehicles {

		go func(v Vehicle) {

			for {

				payload := v.GenerateTelemetry()

				SendTelemetry(s.apiURL, payload)

				time.Sleep(time.Duration(s.interval) * time.Second)

			}

		}(vehicle)
	}

	select {}
}