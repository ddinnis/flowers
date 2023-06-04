export const getGuid = () => {
  return (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1);
};

export const formatToken = (token) => {
  return decodeURIComponent(
    escape(window.atob(token.replace("-", "+").replace("_", "/").split(".")[1]))
  );
};
