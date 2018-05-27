/**
 * Format img url of a object.
 * @param {Array, Object} obj
 * @param {String} url
 */
export default function (obj, url) {
  return  !Array.isArray(obj)
      ? forObject(obj, url)
      : forArray(obj, url);
}

// for object
function forObject (obj, url) {
  Object.keys(obj)
  .filter(key => key.includes('url'))
  .forEach(key => {
    if (obj[key] && obj[key].startsWith('/'))
      obj[key] = url + obj[key]
  })
  return obj;
}

// for array
function forArray (arr, url) {
  return arr.map(obj => forObject(obj, url));
}
