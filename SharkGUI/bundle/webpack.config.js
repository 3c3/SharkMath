module.exports = {
	entry: ["./main.js"],
	output: {
		filename: "../Resources/bundle.js",   
	},
	module: {
		loaders: [
			{ 
				test: /\.js$/,
				exclude: /node_modules/,
				loader: 'babel?cacheDirectory=true,presets[]=react,presets[]=es2015',
			},
			{
                test:   /\.css$/,
                loader: "style-loader!css-loader!postcss-loader"
            },
            {
				test: /\.(eot|woff|woff2|ttf|svg|png|jpg)$/,
				loader: 'url-loader'
			}
		]
	},
	resolve: {
		modulesDirectories: ["node_modules"],
	},
}