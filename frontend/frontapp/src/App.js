import logo from "./logo.svg";
import "./App.css";
import React, { useState } from "react";

function LightingComponent({ text, Edge_device_ID, light_ID }) {
  return (
    <div class="rectangle-component outline-green">
      <p>{text}</p>
      <div className="buttons-container">
        <Light_Button
          button_text="on"
          Edge_device_ID={Edge_device_ID}
          light_ID={light_ID}
          mode="on"
        />
        <Light_Button
          button_text="off"
          Edge_device_ID={Edge_device_ID}
          light_ID={light_ID}
          mode="off"
        />
      </div>
    </div>
  );
}

function turn_light(mode, light_ID, Edge_device_ID) {
  var content = {
    mode: mode,
    light_ID: light_ID,
    Edge_device_ID: Edge_device_ID,
  };
  return async () => {
    try {
      const response = await fetch("http://localhost:3005", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(content),
      });

      const jsonData = await response.json();
      //setResponseData(jsonData);
    } catch (error) {
      console.error("Error posting data:", error);
    }
  };
}

function Light_Button({ button_text, Edge_device_ID, light_ID, mode }) {
  return (
    <button
      class="button"
      onClick={turn_light({ mode, light_ID, Edge_device_ID })}
    >
      {button_text}
    </button>
  );
}

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <LightingComponent text="led number 1" />
        <LightingComponent text="led number 2" />
        <LightingComponent text="led number 3" />
        <LightingComponent text="led number 4" />
        <LightingComponent text="led number 5" />
      </header>
    </div>
  );
}

export default App;
