var
    webpack = require('webpack'),
    path = require('path'),
    ExtractTextPlugin = require("extract-text-webpack-plugin"),
    CopyWebpackPlugin = require("copy-webpack-plugin"),
    HtmlWebpackPlugin = require("html-webpack-plugin")
    ;

module.exports = {
    entry: {
        app: [
            './Resources/Styles/site.scss'
        ]
    },
    output: {
        path: path.resolve(__dirname, 'wwwroot'),
        filename: '[name].js',
        publicPath: "/",        
    },
    mode: 'development',
    devtool: 'inline-source-map',
    
    resolve: {
        extensions: ['.ts', '.tsx']
    },
    module: {
        rules: [
            {
                test: /\.(sass|scss)$/,
                loader: ExtractTextPlugin.extract(['css-loader', 'sass-loader'])
            },
            {
                test: /\.(png|svg|jpg|gif)$/,
                use: [
                    'file-loader'
                ]
            },
            {
                test: /\.(woff|woff2|eot|ttf|otf)$/,
                use: [
                    'file-loader'
                ]
            },
        ]
    },
    plugins: [
        new ExtractTextPlugin("[name].css", { allChunks: true }),
        new HtmlWebpackPlugin({
            inject: 'body',
            filename: '../Features/Shared/_Layout.cshtml',
            template: './Features/Shared/_Layout_Template.cshtml',
            hash: true,
            files: {
                css: ['styles.css'],
                js: ['app.js']
            },
            chucks: {
                head: {
                    css: ['styles.css']
                },
                main: {
                    js: ['app.js']
                }
            }
        }),
        new CopyWebpackPlugin([
            './Resources/Images/abstract-q-c-1280-960-1.jpg',
            './Resources/Images/abstract-q-c-1280-960-4.jpg',
            './Resources/Images/abstract-q-c-1280-960-5.jpg',
            './Resources/Images/abstract-q-c-1280-960-8.jpg',
            './Resources/Images/abstract-q-c-1280-960-9.jpg',
            './Resources/Images/abstract-q-c-1280-960-10.jpg',
            './Resources/Images/logo.png'
        ])
    ]
}