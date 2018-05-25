/**
 * Format img url of a object.
 * @param {*} obj
 * @param {*} url
 */
export default function (obj, url) {
  return  !Array.isArray(obj)
      ? forObject(obj, url)
      : forArray(obj, url);
}

// for object
function forObject (obj, url) {
  Object.keys(obj)
  .filter(key => key.match(/url/))
  .forEach(key => {
    if (obj[key])
      obj[key] = url + obj[key]
  })
  return obj;
}

// for array
function forArray (obj, url) {
  return obj.map(arr => forObject(arr, url));
}
