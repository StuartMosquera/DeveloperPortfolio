'use strict';

window.watchResize = (dotNetHelper, breakpoint) => {
  const query = matchMedia(`(min-width: ${breakpoint}px)`);

  const handler = e => {
    if (e.matches) {
      dotNetHelper.invokeMethod('Close');
    }
  };

  query.onchange = handler;
  handler(query);
};

window.getTheme = () => document.documentElement.getAttribute('data-bs-theme');

window.setTheme = theme => {
  document.documentElement.setAttribute('data-bs-theme', theme);
  localStorage.setItem('theme', theme);
};
