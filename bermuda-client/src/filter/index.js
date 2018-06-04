/**
 * Format url string for starting with `/`
 * @param {String} value
 */
export function urlFilter (value) {
  return value.replace(/^\//g, process.env.URL);
}
