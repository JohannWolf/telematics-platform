package main

import (
	"fmt"
	"telemetry-simulator/config"
	"telemetry-simulator/simulator"
)

func main() {

	cfg := config.LoadConfig()

	fmt.Println("Starting Telemetry Simulator")

	sim := simulator.NewSimulator(
		cfg.VehicleCount,
		cfg.ApiURL,
		cfg.IntervalSec,
	)

	sim.Start()
}