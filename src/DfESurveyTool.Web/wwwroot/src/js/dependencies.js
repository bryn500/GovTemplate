/**
 * This file is loaded synchronously/blocking.
 * Used to load js libraries that are required from any other part of the js
 */

// polyfills
require('./components/polyfills');

// GOVUK scripts
window.GOVUKFrontend = require('govuk-frontend');
GOVUKFrontend.initAll();
