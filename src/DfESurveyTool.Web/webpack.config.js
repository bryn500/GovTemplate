/*
 * Webpack config file
 */
const webpack = require('webpack');
const path = require('path');
const TerserJSPlugin = require('terser-webpack-plugin');
const MiniCssExtractPlugin = require('mini-css-extract-plugin');
const OptimizeCSSAssetsPlugin = require('optimize-css-assets-webpack-plugin');
const CopyPlugin = require('copy-webpack-plugin');

const inProduction = process.env.NODE_ENV === 'production';

const outputDir = path.resolve(__dirname, './wwwroot/assets/');

module.exports = {
    optimization: {
        minimizer: [new TerserJSPlugin({
            cache: !inProduction,
            parallel: true
        }), new OptimizeCSSAssetsPlugin({})],
    },
    plugins: [
        new MiniCssExtractPlugin({
            filename: '[name].css'
        }),
        new CopyPlugin([
            { from: './node_modules/govuk-frontend/govuk/assets', to: outputDir }
        ])
    ],
    devtool: !inProduction ? 'source-map' : false,
    entry: {
        // js
        'js/dependencies': './wwwroot/src/js/dependencies.js',
        'js/app': './wwwroot/src/js/app.js',
        // scss
        'css/all': './wwwroot/src/scss/all.scss'
    },
    output: {
        path: outputDir,
        filename: '[name].min.js'
    },
    module: {
        rules: [
            /*
             * styles
             */
            {
                test: /\.(sa|sc|c)ss$/, // for any css/sass/scss files
                include: [
                    path.resolve(__dirname, "./wwwroot/src/scss/") // in the src/scss folder
                ],
                use: [
                    {
                        loader: MiniCssExtractPlugin.loader, // extracts CSS into files
                        options: {
                            hmr: !inProduction, // hot module reloading on dev
                        },
                    },
                    {
                        loader: 'css-loader', // bundle
                        options: {
                            sourceMap: !inProduction
                        }
                    },
                    {
                        loader: 'sass-loader', // compliles scss to css
                        options: {
                            sourceMap: !inProduction
                        }
                    }
                ]
            },

            /*
             * scripts
             */
            {
                test: /\.js$/, // for all .js files
                include: [
                    path.resolve(__dirname, "./wwwroot/src/js/") // in the src/js folder
                ]
            },
            /*
             * Images
             */
            {
                test: /\.(png|jpe?g|gif|svg)$/,
                loader: 'file-loader',
                options: {
                    name: '[name].[ext]',
                    outputPath: '/images/lib/',
                    publicPath: '/assets/images/lib/',
                    useRelativePaths: true
                }
            }
        ]
    }
};
