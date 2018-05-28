const KEY = 'SEARCH_HISTORY'

export const getSearchHistory = function () {
  let history = localStorage.getItem(KEY);
  return JSON.parse(history);
}

export const updateSearchHistory = function (query) {
  let history = getSearchHistory() || [];

  if (!history.some(i => i == query))
    history.push(query);

  localStorage.setItem(KEY, JSON.stringify(history))
}

export const removeSearchHistory = function () {
  localStorage.removeItem(KEY)
}
