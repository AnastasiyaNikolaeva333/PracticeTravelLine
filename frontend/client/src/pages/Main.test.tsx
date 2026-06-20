import { render, screen, fireEvent } from '@testing-library/react';
import { Main } from './Main';
import { priceChanges } from '../mocks/currencyMocks';

describe('Main', () => {
  it('обновляет значение при вводе суммы', () => {
    render(<Main />);

    const input = screen.getByTestId('from-currency-input') as HTMLInputElement;
    const result = screen.getByTestId('currency-value');

    const selects = screen.getAllByTestId('currency-select');
    const fromSelect = selects[0] as HTMLSelectElement;
    const toSelect = selects[1] as HTMLSelectElement;

    const fromCurrency = fromSelect.value;
    const toCurrency = toSelect.value;

    const rate = priceChanges[fromCurrency]?.[toCurrency]?.price || 0;
    const initialValue = Math.round(1 * rate * 100) / 100;

    expect(input.value).toBe('1');
    expect(result.textContent).toBe(String(initialValue));

    fireEvent.change(input, { target: { value: '100' } });

    const newValue = Math.round(100 * rate * 100) / 100;
    expect(input.value).toBe('100');
    expect(result.textContent).toBe(String(newValue));
  });

  it('меняет валюты при клике на swap', () => {
    render(<Main />);

    const swapButton = screen.getByTestId('swap-button');
    const selects = screen.getAllByTestId('currency-select');
    const fromSelect = selects[0] as HTMLSelectElement;
    const toSelect = selects[1] as HTMLSelectElement;

    const from = fromSelect.value;
    const to = toSelect.value;

    fireEvent.click(swapButton);

    expect(fromSelect.value).toBe(to);
    expect(toSelect.value).toBe(from);
  });
});
