package dataset

import (
	"encoding/csv"
	"os"
)

type RawTelemetry struct {
	TripID    string
	DeviceID  string
	TimeStamp string
	Speed     string
	RPM       string
	Temp      string
	Battery   string
}

func LoadDataset(path string, limit int) ([]RawTelemetry, error) {

	file, err := os.Open(path)
	if err != nil {
		return nil, err
	}

	defer file.Close()

	reader := csv.NewReader(file)

	rows, err := reader.ReadAll()
	if err != nil {
		return nil, err
	}

	var data []RawTelemetry

	for i, row := range rows {

		if i == 0 {
			continue
		}

		if limit > 0 && len(data) >= limit {
			break
		}

		data = append(data, RawTelemetry{
			TripID:    row[0],
			DeviceID:  row[1],
			TimeStamp: row[2],
			Speed:     row[14],
			RPM:       row[13],
			Temp:      row[6],
			Battery:   row[5],
		})
	}

	return data, nil
}