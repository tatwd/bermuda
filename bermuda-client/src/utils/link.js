export function goto (name, id) {
  return {
    name,
    params: {
      id
    }
  }
}

export function queryto (name, query) {
  return {
    name,
    query
  }
}
