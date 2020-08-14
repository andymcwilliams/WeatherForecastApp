import React, { useState, useEffect } from "react";
import Spinner from "react-bootstrap/Spinner";
import Button from "react-bootstrap/Button";
import InputGroup from "react-bootstrap/InputGroup";
import FormControl from "react-bootstrap/FormControl";
import { ForecastCard } from "./ForecastCard";
import authService from "./api-authorization/AuthorizeService";

export const Forecast = () => {
  const [forecast, setForecast] = useState([]);
  const [forecastLoading, setForecastLoading] = useState(true);
  const [forecastFetchFailedMessage, setForecastFetchFailedMessage] = useState(
    ""
  );
  const [forecastLocation, setForecastLocation] = useState("belfast");

  var getForecast = () => {
    setForecastLoading(true);
    authService.getAccessToken().then((token) => {
      fetch("api/weather/forecast/" + forecastLocation, {
        headers: !token ? {} : { Authorization: `Bearer ${token}` },
      })
        .then((response) => response.json())
        .then((data) => {
          setForecast(data);
          setForecastLoading(false);
          setForecastFetchFailedMessage("");
        })
        .catch(() => {
          setForecastLoading(false);
          setForecastFetchFailedMessage(
            "Failed to find forecast for location: " + forecastLocation
          );
        });
    });
  };

  useEffect(() => {
    getForecast();
  }, []);

  var renderForecastCards = (forecasts) => {
    return (
      <div class="card-group">
        {forecasts.slice(0, 5).map((forecast) => (
          <ForecastCard
            date={forecast.dateFormatted}
            weatherStateName={forecast.weatherState.weatherStateName}
            weatherStateAbbreviation={
              forecast.weatherState.weatherStateAbbreviation
            }
          />
        ))}
      </div>
    );
  };

  var handleLocationChange = (e) => {
    setForecastLocation(e.target.value);
  };

  return (
    <React.Fragment>
      <Button onClick={() => getForecast()} variant="primary" size="lg" block>
        Refresh Forecasts
      </Button>

      <InputGroup className="mb-3">
        <FormControl
          placeholder="Location: Belfast"
          aria-label="Location"
          aria-describedby="basic-addon2"
          onChange={handleLocationChange}
        />
        <InputGroup.Append>
          <Button onClick={() => getForecast()} variant="dark">
            Get Forecasts
          </Button>
        </InputGroup.Append>
      </InputGroup>

      {forecastLoading ? (
        <div>
          <div style={{ marginLeft: "50%" }}>
            <Spinner animation="border" />
          </div>
        </div>
      ) : forecastFetchFailedMessage ? (
        <h1>{forecastFetchFailedMessage}</h1>
      ) : (
        <div>{renderForecastCards(forecast)}</div>
      )}
    </React.Fragment>
  );
};
