'use strict';

window.getTheme = () => document.documentElement.getAttribute('data-bs-theme');

window.setTheme = theme => {
  document.documentElement.setAttribute('data-bs-theme', theme);
  localStorage.setItem('theme', theme);
};
