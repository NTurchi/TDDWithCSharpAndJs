import jsdom from "jsdom";

global.document = new jsdom.JSDOM("<html><body></body></html>");
global.window = document.defaultView;

function noop() {
  return {};
}

// prevent mocha tests from breaking when trying to require a css file
require.extensions[".css"] = noop;
require.extensions[".svg"] = noop;
