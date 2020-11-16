/**
 * Sends a custom event to google analytics
 * https://developers.google.com/analytics/devguides/collection/gtagjs/events
 * @param {string} [title] - The page's title
 * @param {string} [path] - The path portion of location. This value must start with a slash(/) character.
 * @param {string} [location] - The page's URL - probably not needed
 */
export function trackPageView(title, path, location) {
    if (!app.gaKey) {
        return;
    }

    var data = {};

    if (title) {
        data.page_title = title;
    }

    if (path) {
        data.page_path = path;
    }

    if (location) {
        data.page_location = location;
    }

    gtag('config', app.gaKey, data);
}


/**
 * Sends a custom event to google analytics
 * https://developers.google.com/analytics/devguides/collection/gtagjs/events
 * @param {string} action - the string that will appear as the event action in Google Analytics Event reports
 * @param {string} [cagtegory] - the string that will appear as the event category
 * @param {string} [label] - the string that will appear as the event label
 * @param {string} [value] - a non-negative integer that will appear as the event value
 */
export function trackEvent(action, cagtegory, label, value) {
    if (!app.gaKey) {
        return;
    }

    if (!action) {
        throw new Error('action is a required parameter.');
    }

    var data = {};

    if (cagtegory) {
        data.event_category = cagtegory;
    }

    if (label) {
        data.event_label = label;
    }

    if (value) {
        data.value = value;
    }

    gtag('event', action, data);
}
