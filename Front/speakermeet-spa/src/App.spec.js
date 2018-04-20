import React from "react";
import ReactDOM from "react-dom";
import { expect } from "chai";

import App from "./App";

describe("Test Framework", () => {
  it("is configured correctly", () => {
    expect(1).to.equal(0);
  });
});

describe("(Component) App", () => {
  it("renders without crashing", () => {
    const div = document.createElement("div");
    ReactDOM.render(<App />, div);
  });
});
