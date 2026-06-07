import { render, screen } from '@testing-library/react';
import { MoreAboutCurrencies } from '../components/MoreAboutCurrencies/MoreAboutCurrencies';

describe('MoreAboutCurrencys Component', () => {
  const currenciesData = [
    {
      title: "Polish zloty - PLN - zł",
      description: "This is the official currency and legal tender of Poland. It is subdivided into 100 grosz-y (gr). It is the most traded currency in Central and Eastern Europe and ranks 21st most-traded in the foreign exchange market."
    },
    {
      title: "Japanese yen - JPY - ¥",
      description: "The yen is the official currency of Japan. It is the third-most traded currency in the foreign exchange market, after the United States dollar and the euro. It is also widely used as a third reserve currency after the US dollar and the euro."
    }
  ];

  it('отображает кнопку с текстом PLN/JPY: about ↑', () => {
    render(<MoreAboutCurrencies currenciesData={currenciesData} />);
    const button = screen.getByText(/PLN\/JPY: about ↑/);
    expect(button).toBeTruthy();
  });

  it('отображает информацию о валютах', () => {
    render(<MoreAboutCurrencies currenciesData={currenciesData} />);

    const title1 = screen.getByText(/Polish zloty - PLN - zł/);
    expect(title1).toBeTruthy();
    expect(screen.getByText(/This is the official currency and legal tender of Poland/i)).toBeTruthy();

    const title2 = screen.getByText(/Japanese yen - JPY - ¥/);
    expect(title2).toBeTruthy();
    expect(screen.getByText(/The yen is the official currency of Japan/i)).toBeTruthy();
  });

  it('сначала идёт кнопка, потом информация о PLN, потом о JPY', () => {
    const { container } = render(<MoreAboutCurrencies currenciesData={currenciesData} />);
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