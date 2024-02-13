import logo from "./logo.svg";
import "./App.css";
import React, { useState } from "react";

var user = {
  name: "noam",
  imageUrl: "https://i.imgur.com/yXOvdOSs.jpg",
};

const products = [
  { title: "Cabbage", id: 1 },
  { title: "Garlic", id: 2 },
  { title: "Apple", id: 3 },
];
function ListProds() {
  const listItems = products.map((product) => (
    <li key={product.id}>{product.title}</li>
  ));

  return <ul>{listItems}</ul>;
}

var turn = "x";

export function Square({ id, row }) {
  const [state, setState] = useState(" ");
  function handleClick() {
    setState(turn);
    turn = turn == "x" ? "o" : "x";
  }
  return (
    <button className="square" ID={id} onClick={handleClick}>
      {state}
    </button>
  );
}

export function Row({ row }) {
  return (
    <div className="board-row" ROW_ID={row}>
      <Square id={1} row={row} />
      <Square id={2} row={row} />
      <Square id={3} row={row} />
    </div>
  );
}
export function Board() {
  return (
    <div>
      <Row row={1} />
      <Row row={2} />
      <Row row={3} />
    </div>
  );
}

function UserName() {
  return (
    <>
      <h1>{user.name}</h1>
      <img className="avatar" src={user.imageUrl} />
    </>
  );
}

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit <code>src/App.js</code> and save to reload.
        </p>
        <UserName />
        <ListProds />
        <Board />
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
      </header>
    </div>
  );
}

export default App;
