/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./src/**/*.{html,ts}"],
  theme: {
    borderColor: (theme) => ({
      ...theme("colors"),
      default: theme("colors.gray.300", "currentColor"),
      primary: "#41719c",
      lines:"#333234",
      text:"#cfcfcf",
      secondary: "#ffed4a",
      danger: "#e3342f",
    }),
    extend: {},
  },
  plugins: [],
};
