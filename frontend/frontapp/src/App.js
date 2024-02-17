import logo from "./logo.svg";
import "./App.css";
import React, { useState } from "react";
import LightingComponent from "./components/LightingComponent";
import importConfig from "./configImport";

const frontcomponents = importConfig();

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        {frontcomponents.map((component, index) => (
          <div key={index}>{component}</div>
        ))}
      </header>
    </div>
  );
}

export default App;
