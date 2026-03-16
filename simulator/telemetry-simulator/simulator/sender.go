package simulator

import (
	"bytes"
	"encoding/json"
	"net/http"
)

func SendTelemetry(url string, payload TelemetryPayload) error {

	body, _ := json.Marshal(payload)

	_, err := http.Post(
		url,
		"application/json",
		bytes.NewBuffer(body),
	)

	return err
}