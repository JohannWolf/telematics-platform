package main

import (
	"fmt"
	"telemetry-simulator/config"
	"telemetry-simulator/dataset"
	"telemetry-simulator/simulator"
)

func main() {

	cfg := config.LoadConfig()

	fmt.Println("Starting dataset stream...")

	stream, err := dataset.StreamDataset("dataset/telemetry.csv")

	if err != nil {
		panic(err)
	}

	engine := simulator.NewReplayEngine(
		cfg.ApiURL,
		cfg.IntervalSec,
	)

	engine.Start(stream)
}