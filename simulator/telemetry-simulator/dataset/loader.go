package dataset

import (
	"encoding/csv"
	"io"
	"os"
)

func StreamDataset(path string) (<-chan RawTelemetry, error) {

	file, err := os.Open(path)
	if err != nil {
		return nil, err
	}

	reader := csv.NewReader(file)

	out := make(chan RawTelemetry)

	go func() {

		defer file.Close()
		defer close(out)

		first := true

		for {

			row, err := reader.Read()

			if err == io.EOF {
				break
			}

			if err != nil {
				continue
			}

			if first {
				first = false
				continue
			}

			raw := RawTelemetry{
				TripID:    row[0],
				DeviceID:  row[1],
				TimeStamp: row[2],
				Speed:     row[14],
				RPM:       row[13],
				Temp:      row[6],
				Battery:   row[5],
			}

			out <- raw
		}

	}()

	return out, nil
}