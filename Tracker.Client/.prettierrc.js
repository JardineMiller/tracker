module.exports = {
	trailingComma: "none",
	tabWidth: 4,
	semi: true,
	singleQuote: false,
	printWidth: 80,
	useTabs: true,
	singleAttributePerLine: true,
	overrides: [
		{
			files: ["*.html"],
			options: {
				printWidth: 120
			}
		}
	]
};