import logo from "./logo.svg";
import "./App.css";
import React, { useState } from "react";

var user = {
  name: "noam",
  imageUrl: "https://i.imgur.com/yXOvdOSs.jpg",
};

const products = [
  { title: "Cabdfghnmbage", id: 1 },
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
var board_state = [
  [null, null, null],
  [null, null, null],
  [null, null, null],
];
function is_winner(board_state) {
  const lines = [
    [0, 1, 2],
    [3, 4, 5],
    [6, 7, 8],
    [0, 3, 6],
    [1, 4, 7],
    [2, 5, 8],
    [0, 4, 8],
    [2, 4, 6],
  ];
  for (let i = 0; i < lines.length; i++) {
    const [a, b, c] = lines[i];
    if (
      board_state[Math.floor(a / 3)][a % 3] &&
      board_state[Math.floor(a / 3)][a % 3] ===
        board_state[Math.floor(b / 3)][b % 3] &&
      board_state[Math.floor(a / 3)][a % 3] ===
        board_state[Math.floor(c / 3)][c % 3]
    ) {
      return board_state[a];
    }
  }
  return null;
}

export function Square({ id, row }) {
  const [state, setState] = useState(" ");
  function handleClick(id, row) {
    if (board_state[id][row] || is_winner(board_state)) {
    } else {
      setState(turn);
      board_state[id][row] = turn;
      turn = turn == "x" ? "o" : "x";
    }
  }
  return (
    <button className="square" ID={id} onClick={() => handleClick(id, row)}>
      {state}
    </button>
  );
}

export function Row({ row }) {
  return (
    <div className="board-row" ROW_ID={row}>
      <Square id={0} row={row} />
      <Square id={1} row={row} />
      <Square id={2} row={row} />
    </div>
  );
}
export function Board() {
  return (
    <div>
      <Row row={0} />
      <Row row={1} />
      <Row row={2} />
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
function Reset() {
  return (
    <>
      <button
        onClick={() =>
          (board_state = [
            [null, null, null],
            [null, null, null],
            [null, null, null],
          ])
        }
      >
        reset
      </button>
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
        <Reset />
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
