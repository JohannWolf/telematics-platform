package simulator

import (
	"time"
	"telemetry-simulator/dataset"
)

type ReplayEngine struct {
	apiURL   string
	interval int
}

func NewReplayEngine(apiURL string, interval int) *ReplayEngine {
	return &ReplayEngine{
		apiURL:   apiURL,
		interval: interval,
	}
}

func (r *ReplayEngine) Start(stream <-chan dataset.RawTelemetry) {

	for row := range stream {

		payload := MapToPayload(row)

		SendTelemetry(r.apiURL, payload)

		time.Sleep(time.Duration(r.interval) * time.Millisecond)
	}
}