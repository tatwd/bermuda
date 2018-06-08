export default function linkTo(name, id) {
  return {
    name,
    params: {
      id
    }
  }
}
