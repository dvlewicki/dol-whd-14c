var webpack = require("webpack");
var path = require('path');

module.exports = {
    devtool: 'eval-source-map',
	entry: './src/modules/app.js',
	output: {
		path: './',
		filename: 'index.js'
	},
	//externals: {
    //},
    eslint: {
        failOnWarning: false,
        failOnError: false
    },
	devServer: {
		inline: true,
		port: 3333
	},
	module: {
        preLoaders: [
            {
                test: /\.jsx?$/,
                exclude: /node_modules/,
                loader: 'eslint'
            }
        ],
		loaders: [
			{
				test: /\.js$/,
				exclude: /node_modules/,
				loader: 'babel',
				query: {
					presets: [ 'es2015' ]
				}
			},
            {
                test: /\.html$/,
                exclude: /node_modules/,
                loader: 'html'
            },
			{
				test: /\.scss$/,
				exclude: /node_modules/,
				loaders: ['style', 'css', 'resolve-url', 'sass?sourceMap']
			},
			{ test: /\.css$/, loader: "style-loader!css-loader" },
  		    {
                test: /\.(png|gif|jpg|jpeg|svg)$/,
                loader: 'url-loader?name=images/[name].[ext]'
            },
            {
    	        test: /\.(ttf|eot|woff|woff2)$/,
                loader: 'url-loader?name=fonts/[name].[ext]'
            }
		]
	},
    plugins: [
        new webpack.ProvidePlugin({
            $: 'jquery',
            jQuery: 'jquery'
        })
    ]
}
