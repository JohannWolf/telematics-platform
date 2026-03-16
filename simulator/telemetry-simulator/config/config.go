package config

import (
	"os"
	"strconv"
)

type Config struct {
	VehicleCount int
	ApiURL       string
	IntervalSec  int
}

func LoadConfig() Config {

	vehicleCount := getEnvInt("VEHICLE_COUNT", 500)
	apiURL := getEnv("API_URL", "http://localhost:5000/api/telemetry")
	interval := getEnvInt("INTERVAL_SECONDS", 5)

	return Config{
		VehicleCount: vehicleCount,
		ApiURL:       apiURL,
		IntervalSec:  interval,
	}
}

func getEnv(key string, defaultValue string) string {

	value := os.Getenv(key)

	if value == "" {
		return defaultValue
	}

	return value
}

func getEnvInt(key string, defaultValue int) int {

	valueStr := os.Getenv(key)

	if valueStr == "" {
		return defaultValue
	}

	value, err := strconv.Atoi(valueStr)

	if err != nil {
		return defaultValue
	}

	return value
}