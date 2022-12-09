const { assert } = require('chai');
const { rgbToHexColor } = require('./rgbToHex');

describe('RGB to Hex Checker', () => {
    it('convert black', () => {
        assert.equal(rgbToHexColor(0, 0, 0), ('#000000'));
    });

    it('convert white', () => {
        assert.equal(rgbToHexColor(255, 255, 255), ('#FFFFFF'));
    });

    it('convert blue', () => {
        assert.equal(rgbToHexColor(35, 68, 101), ('#234465'));
    });

    it('return undefined with missing param', () => {
        assert.equal(rgbToHexColor(0, 0), undefined);
        assert.equal(rgbToHexColor(0), undefined);
        assert.equal(rgbToHexColor(), undefined);
    });

    it('return undefined with lower bound', () => {
        assert.equal(rgbToHexColor(0, 0, -1), undefined);
        assert.equal(rgbToHexColor(0, -1, 0), undefined);
        assert.equal(rgbToHexColor(-1, 0, 0), undefined);
    });

    it('return undefined with upper bound', () => {
        assert.equal(rgbToHexColor(0, 0, 256), undefined);
        assert.equal(rgbToHexColor(0, 256, 0), undefined);
        assert.equal(rgbToHexColor(256, 0, 0), undefined);
    });

    it('return undefined with floats', () => {
        assert.equal(rgbToHexColor(0, 0, 1.1), undefined);
        assert.equal(rgbToHexColor(0, 1.1, 0), undefined);
        assert.equal(rgbToHexColor(1.1, 0, 0), undefined);
    });

    it('return undefined with string', () => {
        assert.equal(rgbToHexColor(0, 0, '1'), undefined);
        assert.equal(rgbToHexColor(0, '1', 0), undefined);
        assert.equal(rgbToHexColor('1', 0, 0), undefined);
    });
});