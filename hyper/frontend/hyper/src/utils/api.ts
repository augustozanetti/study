const BASE = "https://localhost:5001/";

export default {
  get: async (url: string) => {
    return (await fetch(`${BASE}${url}`)).json();
  },
  //@ts-ignore
  post: (url: string, body: RequestInit.Body): Promise<Response> =>
    fetch(`${BASE}${url}`, {
      method: "POST",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json"
      },
      body: JSON.stringify(body)
    }),
  delete: (url: string) =>
    fetch(`${BASE}${url}`, {
      method: "DELETE"
    })
};
