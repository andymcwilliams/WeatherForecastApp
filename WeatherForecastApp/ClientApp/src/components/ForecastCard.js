import React from "react";

export const ForecastCard = (props) => {
  return (
    <div class="card">
      <div class="card-body">
        <h5 class="card-title">{props.date}</h5>
        <p class="card-text">{props.weatherStateName}</p>
      </div>
      <img
        src={`https://www.metaweather.com/static/img/weather/png/${props.weatherStateAbbreviation}.png`}
        alt="weather state image"
        width="200"
        height="200"
      />
    </div>
  );
};
