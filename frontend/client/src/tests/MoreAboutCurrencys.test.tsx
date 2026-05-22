import { render, screen } from '@testing-library/react';
import { MoreAboutCurrencys } from '../components/MoreAboutCurrencys/MoreAboutCurrencys';

describe('MoreAboutCurrencys Component', () => {

  it('отображает кнопку с текстом PLN/JPY: about ↑', () => {
    render(<MoreAboutCurrencys />);
    const button = screen.getByText(/PLN\/JPY: about ↑/);
    expect(button).toBeTruthy();
  });

  it('отображает информацию о валютах', () => {
    render(<MoreAboutCurrencys />);

    const title1 = screen.getByText(/Polish zloty - PLN - zł/);
    expect(title1).toBeTruthy();
    expect(screen.getByText(/This is the official currency and legal tender of Poland/i)).toBeTruthy();

    const title2 = screen.getByText(/Japanese yen - JPY - ¥/);
    expect(title2).toBeTruthy();
    expect(screen.getByText(/The yen is the official currency of Japan/i)).toBeTruthy();
  });

  it('отображает линию (разделитель)', () => {
    const { container } = render(<MoreAboutCurrencys />);
    const line = container.querySelector('[class*="line"]');
    expect(line).toBeTruthy();
  });

  it('сначала идёт кнопка, потом информация о PLN, потом о JPY', () => {
    const { container } = render(<MoreAboutCurrencys />);
    const html = container.innerHTML;

    const buttonIndex = html.indexOf('PLN/JPY: about');
    const plnIndex = html.indexOf('Polish zloty');
    const jpyIndex = html.indexOf('Japanese yen');

    expect(buttonIndex).toBeGreaterThan(-1);
    expect(plnIndex).toBeGreaterThan(-1);
    expect(jpyIndex).toBeGreaterThan(-1);

    expect(buttonIndex).toBeLessThan(plnIndex);
    expect(plnIndex).toBeLessThan(jpyIndex);
  });
});