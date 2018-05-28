const KEY = 'SEARCH_HISTORY'

export const getSearchHistory = function () {
  let history = localStorage.getItem(KEY);
  return history ? JSON.parse(history) : null;
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
