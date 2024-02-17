import React from "react";
import LightingComponent from "./components/LightingComponent";

const response = await fetch("http://localhost:3005/api/config/", {
  method: "GET",
  headers: {
    "Content-Type": "application/json",
  },
});

const jsonData = await response.json();

const frontcomponents = [];
for (const device of jsonData.devices) {
  for (const ENDPOINT of device[Object.keys(device)[0]].ENDPOINTS) {
    if (ENDPOINT[Object.keys(ENDPOINT)[0]].Type === "light") {
      frontcomponents.push(
        <LightingComponent
          text={Object.keys(ENDPOINT)[0]}
          Edge_device_ID={ENDPOINT[Object.keys(ENDPOINT)[0]].ID}
          light_ID={ENDPOINT[Object.keys(ENDPOINT)[0]].lightID}
        />
      );
    }
  }
}
export default function importConfig() {
  return frontcomponents;
}
