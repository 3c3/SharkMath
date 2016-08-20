var autoprefixer	= require('autoprefixer');
var precss			= require('precss');
var lost 			= require('lost');
var cssnext 		= require('cssnext');
var EncodingPlugin 	= require('webpack-encoding-plugin');
var BomPlugin 		= require('webpack-utf8-bom');
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
				loader: 'babel',
				query: {
					cacheDirectory: true,
					plugins: ['transform-runtime'],
					presets: ['es2015', 'stage-0', 'react'],
				}

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
	postcss: function () {
		return {
			defaults: [autoprefixer, precss, lost, cssnext],
			cleaner:  [autoprefixer({ browsers: ['last 1 version'] })]
		};
	},
	resolve: {
		modulesDirectories: ["node_modules"],
	},
	plugins: [/*new EncodingPlugin('utf-8'),*/ new BomPlugin(true)]
}